/*
 * Copyright � 2002-2011 the original author or authors.
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
using System.Runtime.Serialization;
using Solenoid.Expressions.Support.Util;

namespace Solenoid.Expressions
{
    /// <summary>
    /// Represents NOT operator (both, bitwise and logical).
    /// </summary>
    /// <author>Aleksandar Seovic</author>
    [Serializable]
    public class OpNot : UnaryOperator
    {
        /// <summary>
        /// Create a new instance
        /// </summary>
        public OpNot()
        {
        }

        /// <summary>
        /// Create a new instance
        /// </summary>
        public OpNot(BaseNode operand)
            :base(operand)
        {
        }

        /// <summary>
        /// Create a new instance from SerializationInfo
        /// </summary>
        protected OpNot(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        
        /// <summary>
        /// Returns a value for the logical NOT operator node.
        /// </summary>
        /// <param name="context">Context to evaluate expressions against.</param>
        /// <param name="evalContext">Current expression evaluation context.</param>
        /// <returns>Node's value.</returns>
        protected override object Get(object context, EvaluationContext evalContext)
        {
            var operand = GetValue(Operand, context, evalContext);
            if (NumberUtils.IsInteger(operand))
            {
                return NumberUtils.BitwiseNot(operand);
            }
	        if (operand is Enum)
	        {
		        var enumType = operand.GetType();
		        var integralType = Enum.GetUnderlyingType(enumType);
		        operand = Convert.ChangeType(operand, integralType);
		        var result = NumberUtils.BitwiseNot(operand);
		        return Enum.ToObject(enumType, result);
	        }
	        return !Convert.ToBoolean(operand);
        }
    }
}