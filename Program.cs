using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator {

    class Program {

        static void Main(string[] args) {


            var v = new CommonValidatorBuilder<string>()
                                    .AddRule(s => s.Length < 10)
                                    .AddRule(s => s.Length > 0)
                                    .Build();
            

        }
    }

    public class CommonValidator<TSource> {

        private IList<Predicate<TSource>> rules;

        internal CommonValidator(IList<Predicate<TSource>> predicates) {
            this.rules = predicates;
        } 
        
    }

    public class CommonValidatorBuilder<TSource> {

        private IList<Predicate<TSource>> predicates;

        public CommonValidatorBuilder() {
            this.predicates = new List<Predicate<TSource>>();
        }

        public CommonValidatorBuilder<TSource> AddRule(Predicate<TSource> predicate) {
            this.predicates.Add(predicate);
            return this;
        }

        public CommonValidator<TSource> Build() {
            return new CommonValidator<TSource>(predicates);
        }

    }

    public abstract class BaseRule<TSource> {

    }

    public class SimpleRule<TSource> : BaseRule<TSource> {

    }

    public class DatabaseRule<TSource> : BaseRule<TSource> {

    }
}
