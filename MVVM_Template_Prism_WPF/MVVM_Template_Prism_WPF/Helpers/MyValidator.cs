using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace MVVM_Template_Prism_WPF.Helpers
{
    public class MyValidator
    {
        /// <summary>
        /// Validate your model with its Data Annotations
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>Return a Tuple with IsValid and a collection with the Validation Results</returns>
        public static Tuple<bool, List<ValidationResult>> TryValidateObject<T>(T obj)
        {
            try
            {
                var Context = new ValidationContext(obj, null, null);
                var Result = new List<ValidationResult>();

                var isValid = Validator.TryValidateObject(obj, Context, Result, true);

                return Tuple.Create(isValid,Result);

            }
            catch(Exception ex)
            {
                return Tuple.Create(false, new List<ValidationResult>());
            }
        } 

    }
}
