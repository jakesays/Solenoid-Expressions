
/*
 * Copyright 2002-2010 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */



using System;
using System.Collections;
using System.Collections.Generic;
using Solenoid.Expressions.Support.Util;


namespace Solenoid.Expressions.Support.TypeConversion
{
    /// <summary>
    /// Utility methods that are used to convert objects from one type into another.
    /// </summary>
    /// <author>Aleksandar Seovic</author>
    public static class TypeConversionUtils
    {
        /// <summary>
        /// Convert the value to the required <see cref="System.Type"/> (if necessary from a string).
        /// </summary>
        /// <param name="newValue">The proposed change value.</param>
        /// <param name="requiredType">
        /// The <see cref="System.Type"/> we must convert to.
        /// </param>
        /// <param name="propertyName">Property name, used for error reporting purposes...</param>
        /// <returns>The new value, possibly the result of type conversion.</returns>
        public static object ConvertValueIfNecessary(Type requiredType, object newValue, string propertyName)
        {
            if (newValue != null)
            {
                // if it is assignable, return the value right away
                if (IsAssignableFrom(newValue, requiredType))
                {
                    return newValue;
                }

                // if required type is an array, convert all the elements
                if (requiredType != null && requiredType.IsArray)
                {
                    // convert individual elements to array elements
                    var componentType = requiredType.GetElementType();
                    if (newValue is ICollection)
                    {
                        var elements = (ICollection)newValue;
                        return ToArrayWithTypeConversion(componentType, elements, propertyName);
                    }
	                if (newValue is string)
	                {
		                if (requiredType == typeof(char[]))
		                {
			                return ((string)newValue).ToCharArray();
		                }
		                var elements = StringUtils.CommaDelimitedListToStringArray((string)newValue);
		                return ToArrayWithTypeConversion(componentType, elements, propertyName);
	                }
	                if (!newValue.GetType().IsArray)
	                {
		                // A plain value: convert it to an array with a single component.
		                var result = Array.CreateInstance(componentType, 1);
		                var val = ConvertValueIfNecessary(componentType, newValue, propertyName);
		                result.SetValue(val, 0);
		                return result;
	                }
                }

                // if required type is some IList<T>, convert all the elements
                if (requiredType != null && requiredType.IsGenericType && TypeImplementsGenericInterface(requiredType, typeof(IList<>)))
                {
                    // convert individual elements to array elements
                    var componentType = requiredType.GetGenericArguments()[0];
                    if (newValue is ICollection)
                    {
                        var elements = (ICollection)newValue;
                        return ToTypedCollectionWithTypeConversion(typeof(List<>), componentType, elements, propertyName);
                    }
                }

                // if required type is some IDictionary<K,V>, convert all the elements
                if (requiredType != null && requiredType.IsGenericType && TypeImplementsGenericInterface(requiredType, typeof(IDictionary<,>)))
                {
                    var typeParameters = requiredType.GetGenericArguments();
                    var keyType = typeParameters[0];
                    var valueType = typeParameters[1];
                    if (newValue is IDictionary)
                    {
                        var elements = (IDictionary)newValue;
                        var targetCollectionType = typeof(Dictionary<,>);
                        var collectionType = targetCollectionType.MakeGenericType(new[] { keyType, valueType });
                        var typedCollection = Activator.CreateInstance(collectionType);

                        var addMethod = collectionType.GetMethod("Add", new[] { keyType, valueType });
                        var i = 0;
                        foreach (DictionaryEntry entry in elements)
                        {
                            var propertyExpr = BuildIndexedPropertyName(propertyName, i);
                            var key = ConvertValueIfNecessary(keyType, entry.Key, propertyExpr + ".Key");
                            var value = ConvertValueIfNecessary(valueType, entry.Value, propertyExpr + ".Value");
                            addMethod.Invoke(typedCollection, new[] { key, value });
                            i++;
                        }
                        return typedCollection;
                    }
                }

                // if required type is some IEnumerable<T>, convert all the elements
                if (requiredType != null &&
					requiredType.IsGenericType && 
					TypeImplementsGenericInterface(requiredType, typeof(IEnumerable<>)))
                {
                    // convert individual elements to array elements
                    var componentType = requiredType.GetGenericArguments()[0];
                    if (newValue is ICollection)
                    {
                        var elements = (ICollection)newValue;
                        return ToTypedCollectionWithTypeConversion(typeof(List<>), componentType, elements, propertyName);
                    }
                }

                // try to convert using type converter
                try
                {
                    var typeConverter = TypeConverterRegistry.GetConverter(requiredType);
                    if (typeConverter != null && typeConverter.CanConvertFrom(newValue.GetType()))
                    {
                        try
                        {
                            newValue = typeConverter.ConvertFrom(newValue);
                        }
                        catch
                        {
                            if (newValue is string)
                            {
                                newValue = typeConverter.ConvertFromInvariantString((string)newValue);
                            }
                        }
                    }
                    else
                    {
                        typeConverter = TypeConverterRegistry.GetConverter(newValue.GetType());
                        if (typeConverter != null && typeConverter.CanConvertTo(requiredType))
                        {
                            newValue = typeConverter.ConvertTo(newValue, requiredType);
                        }
                        else
                        {
                            // look if it's an enum
                            if (requiredType != null &&
                                requiredType.IsEnum &&
                                (!(newValue is float) &&
                                    (!(newValue is double))))
                            {
                                // convert numeric value into enum's underlying type
                                var numericType = Enum.GetUnderlyingType(requiredType);
                                newValue = Convert.ChangeType(newValue, numericType);

                                if (Enum.IsDefined(requiredType, newValue))
                                {
                                    newValue = Enum.ToObject(requiredType, newValue);
                                }
                                else
                                {
                                    throw new TypeMismatchException(
                                        CreatePropertyChangeEventArgs(propertyName, null, newValue), requiredType);
                                }
                            }
                            else if (newValue is IConvertible)
                            {
                                // last resort - try ChangeType
                                newValue = Convert.ChangeType(newValue, requiredType);
                            }
                            else
                            {
                                throw new TypeMismatchException(
                                    CreatePropertyChangeEventArgs(propertyName, null, newValue), requiredType);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new TypeMismatchException(
                        CreatePropertyChangeEventArgs(propertyName, null, newValue), requiredType, ex);
                }
                if (newValue == null && (requiredType == null || !Type.GetType("System.Nullable`1").Equals(requiredType.GetGenericTypeDefinition())))
                {
                    throw new TypeMismatchException(
                        CreatePropertyChangeEventArgs(propertyName, null, newValue), requiredType);
                }
            }
            return newValue;
        }

        private static object ToArrayWithTypeConversion(Type componentType, ICollection elements, string propertyName)
        {
            var destination = Array.CreateInstance(componentType, elements.Count);
            var i = 0;
            foreach (var element in elements)
            {
                var value = ConvertValueIfNecessary(componentType, element, BuildIndexedPropertyName(propertyName, i));
                destination.SetValue(value, i);
                i++;
            }
            return destination;
        }

        private static object ToTypedCollectionWithTypeConversion(Type targetCollectionType, Type componentType, ICollection elements, string propertyName)
        {
            if (!TypeImplementsGenericInterface(targetCollectionType, typeof(ICollection<>)))
            {
                throw new ArgumentException("argument must be a type that derives from ICollection<T>", "targetCollectionType");
            }


            var collectionType = targetCollectionType.MakeGenericType(new[] { componentType });

            var typedCollection = Activator.CreateInstance(collectionType);

            var i = 0;
            foreach (var element in elements)
            {
                var value = ConvertValueIfNecessary(componentType, element,
					BuildIndexedPropertyName(propertyName, i));
                collectionType.GetMethod("Add").Invoke(typedCollection, new[] { value });
                i++;
            }
            return typedCollection;
        }

        private static string BuildIndexedPropertyName(string propertyName, int index)
        {
            return (propertyName != null ?
                    propertyName + "[" + index + "]" :
                    null);
        }

        private static bool IsAssignableFrom(object newValue, Type requiredType)
        {
            if (newValue is MarshalByRefObject)
            {
                //TODO see what type of type checking can be done.  May need to 
                //preserve information when proxy was created by SaoServiceExporter.
                return true;
            }
            if (requiredType == null)
            {
                return false;
            }
            return requiredType.IsAssignableFrom(newValue.GetType());
        }

        /// <summary>
        /// Utility method to create a property change event.
        /// </summary>
        /// <param name="fullPropertyName">
        /// The full name of the property that has changed.
        /// </param>
        /// <param name="oldValue">The property old value</param>
        /// <param name="newValue">The property new value</param>
        /// <returns>
        /// A new <see cref="PropertyChangeEventArgs"/>.
        /// </returns>
        private static PropertyChangeEventArgs CreatePropertyChangeEventArgs(string fullPropertyName, object oldValue,
                                                                             object newValue)
        {
            return new PropertyChangeEventArgs(fullPropertyName, oldValue, newValue);
        }

        /// <summary>
        /// Determines if a Type implements a specific generic interface.
        /// </summary>
        /// <param name="candidateType">Candidate <see lang="Type"/> to evaluate.</param>
        /// <param name="matchingInterface">The <see lang="interface"/> to test for in the Candidate <see lang="Type"/>.</param>
        /// <returns><see lang="true" /> if a match, else <see lang="false"/></returns>
        private static bool TypeImplementsGenericInterface(Type candidateType, Type matchingInterface)
        {
            if (!matchingInterface.IsInterface)
            {
                throw new ArgumentException("matchingInterface Type must be an Interface Type", "matchingInterface");
            }

            if (candidateType.IsInterface && IsMatchingGenericInterface(candidateType, matchingInterface))
            {
                return true;
            }

            var match = false;
            var implementedInterfaces = candidateType.GetInterfaces();
            foreach (var interfaceType in implementedInterfaces)
            {
                if (IsMatchingGenericInterface(interfaceType, matchingInterface))
                {
                    match = true;
                    break;
                }
            }

            return match;
        }

        private static bool IsMatchingGenericInterface(Type candidateInterfaceType, 
			Type matchingGenericInterface)
        {
            return candidateInterfaceType.IsGenericType &&
				candidateInterfaceType.GetGenericTypeDefinition() == matchingGenericInterface;
        }
    }
}
