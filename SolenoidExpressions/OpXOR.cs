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
using System.Runtime.Serialization;
using Solenoid.Expressions.Support.Util;

namespace Solenoid.Expressions
{
    /// <summary>
    /// </summary>
    /// <author>Erich Eichinger</author>
    [Serializable]
    public class OpXor : BinaryOperator
    {
        /// <summary>
        /// Create a new instance
        /// </summary>
        public OpXor()
        { }

        /// <summary>
        /// Create a new instance
        /// </summary>
        public OpXor(BaseNode left, BaseNode right)
            :base(left, right)
        {
        }

        /// <summary>
        /// Create a new instance from SerializationInfo
        /// </summary>
        protected OpXor(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        
        /// <summary>
        /// Returns a value for the logical AND operator node.
        /// </summary>
        /// <param name="context">Context to evaluate expressions against.</param>
        /// <param name="evalContext">Current expression evaluation context.</param>
        /// <returns>Node's value.</returns>
        protected override object Get(object context, EvaluationContext evalContext)
        {
            var lhs = GetLeftValue(context, evalContext);
            var rhs = GetRightValue(context, evalContext);

            if (NumberUtils.IsInteger(lhs) && NumberUtils.IsInteger(rhs))
            {
                return NumberUtils.BitwiseXor(lhs, rhs);
            }
	        if (lhs is Enum && lhs.GetType() == rhs.GetType())
	        {
		        var enumType = lhs.GetType();
		        var integralType = Enum.GetUnderlyingType(enumType);
		        lhs = Convert.ChangeType(lhs, integralType);
		        rhs = Convert.ChangeType(rhs, integralType);
		        var result = NumberUtils.BitwiseXor(lhs, rhs);

		        return Enum.ToObject(enumType, result);
	        }
	        return Convert.ToBoolean(lhs) ^ Convert.ToBoolean(rhs);
        }
    }
}