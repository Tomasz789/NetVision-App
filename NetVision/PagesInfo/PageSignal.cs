using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVision.PagesInfo
{
    public abstract class PageSignal<T>
    {
        private T frameworkElement;
        List<T> frameworkCollection = new List<T>();

        public PageSignal(T element)
        {
            frameworkElement = element;
        }

        private bool CanExecute()
        {
            return true;
        }

        public bool isChoosen(T page)
        {
            return true;
        }
        public T CurrentPageEnabled(T page)
        {
            SetPreviousPage(page);
            frameworkCollection.Add(page);
            return page;
        }

        private void SetPreviousPage(T page)
        {
            T previous = page;
        }
    }
}
