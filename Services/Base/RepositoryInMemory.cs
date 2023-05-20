using Cataloguer.Models.Interfaces;
using Cataloguer.Resources.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cataloguer.Services.Base
{
    abstract class RepositoryInMemory<T> : IRepository<T> where T : IEntity
    {
        private readonly List<T> _Items = new();

        private int _LastId;
        protected RepositoryInMemory() { }

        protected RepositoryInMemory(IEnumerable<T> items)
        {
            foreach(var item in items)
                Add(item);

        }
        

        public void Add(T item)
        {
            //проверка на пустую ссылку
            if(item is null) throw new ArgumentNullException(nameof(item));

            //проверка существует ли уже в списке
            if(_Items.Contains(item)) return;
            
            //инкримент последнего идентификтора
            item.Id = ++_LastId;
            
            //добавление в список
            _Items.Add(item);
        }

        public IEnumerable<T> GetAll() => _Items;

        public bool Remove(T item) => _Items.Remove(item);

        public void Update(int id, T item)
        {
            //проверка на пустую ссылку
            if (item is null) throw new ArgumentNullException(nameof(item));
            if(id <=0) throw new ArgumentOutOfRangeException(nameof(id), id, "Индекс не может быть меньше 1");

            //проверка на существования элемента в списке. Если есть - уже обновлен, делаем return
            if (_Items.Contains(item)) return;

            //пытаемся извлеч из репозитория объект для обновления
            //если не удалось - работает исключение
            var db_item = ((IRepository<T>) this).Get(id);
            if (db_item is null)
                throw new InvalidOperationException("Редактируемый элемент не найден в репозитории.");

            Update(item, db_item);
        }

        protected abstract void Update(T Source,  T Destination);
    }
}
