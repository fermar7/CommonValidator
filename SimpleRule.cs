using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator {
    
    public class SimpleRule<TSource> : BaseRule<TSource> {

        private Func<TSource, bool> predicate;

        public SimpleRule(Func<TSource, bool> predicate) {
            this.predicate = predicate;
        }

        public SimpleRule(Func<TSource, bool> predicate, Action<TSource> onInvalid) {
            this.predicate = predicate;
            this.onInvalid = onInvalid;
        }

        public override bool Test(TSource source) {
            if (predicate(source)) {
                return true;
            }

            onInvalid?.Invoke(source);

            return false;

        }
    }
}
