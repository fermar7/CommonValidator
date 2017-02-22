using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validator {

    public class DatabaseRule<TSource> : BaseRule<TSource> {

        private Func<IQueryable<TSource>, TSource, bool> predicate;

        public DatabaseRule(Func<IQueryable<TSource>, TSource, bool> predicate) {
            this.predicate = predicate;
        }

        public DatabaseRule(Func<IQueryable<TSource>, TSource, bool> predicate, Action<TSource> onInvalid) {
            this.predicate = predicate;
            this.onInvalid = onInvalid;
        }

        public override bool Test(TSource source) {

            //Here could be your database access!

            //IEnumerable<T>, DataSet<T>, ... could be used too
            //Datasource injection planned


            IQueryable<TSource> testList = new List<TSource>().AsQueryable();

            if (predicate(testList, source)) {
                return true;
            }

            onInvalid?.Invoke(source);

            return false;
        }

    }
}
