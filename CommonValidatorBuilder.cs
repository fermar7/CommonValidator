using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator {

    public class CommonValidatorBuilder<TSource> {

        private IList<BaseRule<TSource>> predicates;

        internal IList<BaseRule<TSource>> Rules => predicates;

        public CommonValidatorBuilder() {
            this.predicates = new List<BaseRule<TSource>>();
        }

        public CommonValidatorBuilder<TSource> AddSimpleRule(Func<TSource, bool> predicate) {
            this.predicates.Add(new SimpleRule<TSource>(predicate));
            return this;
        }

        public CommonValidatorBuilder<TSource> AddSimpleRule(Func<TSource, bool> predicate, Action<TSource> onInvalid) {
            this.predicates.Add(new SimpleRule<TSource>(predicate, onInvalid));
            return this;
        }

        public CommonValidatorBuilder<TSource> AddDatabaseRule(Func<IQueryable<TSource>, TSource, bool> predicate) {
            this.predicates.Add(new DatabaseRule<TSource>(predicate));
            return this;
        }

        public CommonValidatorBuilder<TSource> AddDatabaseRule(Func<IQueryable<TSource>, TSource, bool> predicate, Action<TSource> onInvalid) {
            this.predicates.Add(new DatabaseRule<TSource>(predicate, onInvalid));
            return this;
        }

        public CommonValidator<TSource> Build() {
            return new CommonValidator<TSource>(this);
        }

    }
}
