using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Delegate.Models
{
    public class ElementList
    {
        private List<int> _InternalContent;


        //public IEnumerable<int> Content
        //{
        //    // Fonctionnel, mais duplication des données en memoire
        //    get { return new List<int>(_InternalContent); }
        //}

        //public IEnumerable<int> Content
        //{
        //    // Retour des données sous forme d'un yield return => OK
        //    get
        //    {
        //        foreach (var item in _InternalContent)
        //        {
        //            yield return item;
        //        }
        //    }
        //}

        public IEnumerable<int> Content
        {

            get { return _InternalContent.Select(elem => elem); }
        }

        public ElementList()
        {
            _InternalContent = new List<int>();
        }

        public void Generate(int count)
        {
            Random rng = new Random();

            for (int i = 0; i < count; i++)
            {
                _InternalContent.Add(rng.Next(-100, 101));
            }
        }

        public IEnumerable<int> GetEven()
        {
            foreach (int value in _InternalContent)
            {
                if(value % 2 == 0)
                {
                    yield return value;
                }
            }
        }

        public IEnumerable<int> GetOdd()
        {
            foreach (int value in _InternalContent)
            {
                if (value % 2 != 0)
                {
                    yield return value;
                }
            }
        }

        public IEnumerable<int> Filter(LeDelegateDeNico del)
        {
            foreach (int value in _InternalContent)
            {
                if (del(value))
                {
                    yield return value;
                }
            }
        }
    }

    public delegate bool LeDelegateDeNico(int v);
}
