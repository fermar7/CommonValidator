using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator {

    public abstract class BaseRule<TSource> {

        protected Action<TSource> onInvalid;

        public abstract bool Test(TSource source);

    }
}
