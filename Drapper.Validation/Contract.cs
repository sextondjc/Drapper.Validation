﻿// ============================================================================================================================= 
// author           : david sexton (@sextondjc | sextondjc.com)
// date             : 2015.12.23
// modified         : 2017-03-11 (16:03)
// licence          : licensed under the terms of the MIT license. See LICENSE.txt
// =============================================================================================================================
using System;

namespace Drapper.Validation
{
    /// <summary>
    /// A simple precondition checker. Useful for validating method arguments. 
    /// </summary>
    public class Contract
    {
        [Obsolete("This method will be removed in the next major release. Please use Require<T> for new development.")]
        public static void Require(bool condition, string message, params object[] args)
        {
            if (!condition)
            {
                throw new ArgumentException(string.Format(message, args));
            }
        }

        /// <summary>
        /// Evaluates the supplied condition and throws exception on failure. 
        /// </summary>
        /// <typeparam name="TException">The type of exception to be thrown.</typeparam>
        /// <param name="condition">The condition to be evaluated.</param>
        /// <param name="message">Optional information to appear in the exception message.</param>
        /// <param name="args">Any additional arguments to be part of the exception message.</param>
        public static void Require<TException>(bool condition, string message, params object[] args) where TException : Exception
        {
            if (!condition)
            {
                throw Activator.CreateInstance(typeof(TException), string.Format(message, args)) as TException;
            }
        }

        /// <summary>
        /// Evaluates the supplied condition and throws exception on failure. 
        /// </summary>
        /// <typeparam name="TException">The type of exception to be thrown.</typeparam>
        /// <param name="condition">The condition to be evaluated.</param>
        /// <param name="message">Optional information to appear in the exception message.</param>
        /// <param name="innerException">An optional inner exception to include with the exception.</param>
        /// <param name="args">Any additional arguments to be part of the exception message.</param>
        public static void Require<TException>(bool condition, string message, Exception innerException = null, params object[] args) where TException : Exception
        {
            if (!condition)
            {                
                throw Activator.CreateInstance(typeof(TException), string.Format(message, args), innerException) as TException;
            }
        }
    }    
}
