using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator {

    public class CommonValidator<TSource> {

        private IList<BaseRule<TSource>> rules;

        internal CommonValidator(CommonValidatorBuilder<TSource> builder) {
            //Rules are tested in the order of the builder pattern
            this.rules = builder.Rules.Reverse().ToList();
        }


        public bool Validate(TSource source) {
            foreach (var rule in rules) {
                if(!rule.Test(source)) {
                    return false;
                }
            }

            return true;
        }

    }
}
