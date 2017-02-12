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

        private IList<BaseRule<TSource>> rules;

        internal CommonValidator(IList<BaseRule<TSource>> predicates) {
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

        private IEnumerable<BaseRule<TSource>> GetRules() {
            foreach (var predicate in predicates) {
                yield return new SimpleRule<TSource>(predicate);
            }
        }

        public CommonValidator<TSource> Build() {
            
            return new CommonValidator<TSource>(this.GetRules().ToList());
        }

    }

    public abstract class BaseRule<TSource> {

        protected Predicate<TSource> predicate;

        protected BaseRule(Predicate<TSource> predicate) {
            this.predicate = predicate;
        }

        public abstract bool Test(TSource source);

    }

    public class SimpleRule<TSource> : BaseRule<TSource> {
        
        public SimpleRule(Predicate<TSource> predicate)
            : base(predicate) { }

        public override bool Test(TSource source) {
            return predicate(source);
        }
    }

    public class DatabaseRule<TSource> : BaseRule<TSource> {

        public DatabaseRule(Predicate<TSource> predicate) : base(predicate) {
        }

        public override bool Test(TSource source) {
            throw new NotImplementedException();
        }

    }
}
