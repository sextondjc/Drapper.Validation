// ============================================================================================================================= 
// author           : david sexton (@sextondjc | sextondjc.com)
// date             : 2015.12.23
// modified         : 2017-03-11 (16:50)
// licence          : licensed under the terms of the MIT license. See LICENSE.txt
// =============================================================================================================================
using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using static Drapper.Validation.Contract;

namespace Drapper.Validation.Attributes
{
    public sealed class RequiredCollectionAttribute : ValidationAttribute
    {
        public int MinimumCount { get; }
        public int MaximumCount { get; }

        public RequiredCollectionAttribute(int minimumCount)
        {
            this.MinimumCount = minimumCount;
        }

        public RequiredCollectionAttribute(int minimumCount, int maximumCount):this(minimumCount)
        {
            this.MaximumCount = maximumCount;
        }
        
        public override bool IsValid(object value)
        {
            var result = true;
            Require<ArgumentNullException>(value != null, "The object passed to the attribute was null.");            

            // cast to IEnumerable & get length
            var length = 0;
            foreach (var item in ((IEnumerable)value))
            {
                length++;
            }

            if (length < MinimumCount)
            {
                // doesn't meet minimum length
                ErrorMessage = $"The collection length of {length} is less than the minimum required of {MinimumCount}";
                return false;
            }

            // max length is allowed to be zero. 
            if (MaximumCount != 0)
            {
                if (length > MaximumCount)
                {
                    ErrorMessage = $"The collection length of {length} is greated than the maximum required of {MaximumCount}";
                    return false;
                }
            }

            return result;
        }
    }
}
