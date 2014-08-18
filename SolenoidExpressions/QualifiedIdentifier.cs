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

namespace Solenoid.Expressions
{
    /// <summary>
    /// Represents parsed named argument node in the expression.
    /// </summary>
    /// <author>Aleksandar Seovic</author>
    [Serializable]
    public class QualifiedIdentifier : BaseNode
    {
        private string _identifier;

        /// <summary>
        /// Create a new instance
        /// </summary>
        public QualifiedIdentifier()
        {
        }

        /// <summary>
        /// Create a new instance from SerializationInfo
        /// </summary>
        protected QualifiedIdentifier(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Returns the value of the named argument defined by this node.
        /// </summary>
        /// <param name="context">Context to evaluate expressions against.</param>
        /// <param name="evalContext">Current expression evaluation context.</param>
        /// <returns>Node's value.</returns>
        protected override object Get(object context, EvaluationContext evalContext)
        {
            if (_identifier == null)
            {
                lock (this)
                {
                    if (_identifier == null)
                    {
                        _identifier = getText();
                    }
                }
            }

            return _identifier;
        }

        /// <summary>
        /// Overrides getText to allow easy way to get fully 
        /// qualified identifier.
        /// </summary>
        /// <returns>
        /// Fully qualified identifier as a string.
        /// </returns>
        public override string getText()
        {
            var tmp = base.getText();
//            if (tmp != null)
//            {
//                tmp = tmp.Replace(ESCAPE_CHAR, ""); // remove all occurrences of escape char
//            }
            var node = getFirstChild();
            while (node != null)
            {
                tmp = string.Concat(tmp, node.getText());
                node = node.getNextSibling();
            }
            return tmp;
        }
    }
}