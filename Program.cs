using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator {

    class Program {
        
        static void Main(string[] args) {

            string majesticTestingString = "Hello";

            
            CommonValidator<string> v = new CommonValidatorBuilder<string>()
                                    .AddSimpleRule(s => s.Length < 10)
                                    .AddSimpleRule(s => s.Length > 0)
                                    .AddDatabaseRule((q, s) => !q.Contains(s))
                                    .Build();

            v.Validate(majesticTestingString);  // => TRUE

            int majesticTestingInt = 23;

            Validators.NumberValidator.Validate(majesticTestingInt); // => FALSE

            Console.ReadLine();
        }
    }
    
    
    class Validators {

        //Prints "23 is not even", because the second rule isn't met
        public static CommonValidator<int> NumberValidator => new CommonValidatorBuilder<int>()
                                                            .AddSimpleRule(i => i < 100)
                                                            .AddSimpleRule(i => i % 2 == 0, i => Console.WriteLine($"{i} is not even."))
                                                            .Build();

    } 
}
