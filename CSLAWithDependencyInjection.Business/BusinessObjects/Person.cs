using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;
using CSLAWithDependencyInjection.Business.BaseClasses;
using CSLAWithDependencyInjection.Data.Models;
using CSLAWithDependencyInjection.Business.Interfaces;

namespace CSLAWithDependencyInjection.Business.BusinessObjects
{
    [Serializable]
    public class Person : CustomBusinessBase<Person>, IPerson
    {
        private Person()
        {

        }

        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get { return GetProperty(IdProperty); }
            set { SetProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(c => c.Name);
        public string Name
        {
            get { return GetProperty(NameProperty); }
            set { SetProperty(NameProperty, value); }
        }

        // static factory methods
        public static Person Create()
        {
            return DataPortal.Create<Person>();
        }

        public static Person Fetch(int id)
        {
            return DataPortal.Fetch<Person>(id);
        }


        private void DataPortal_Fetch(int id)
        {
            var person = this.Context.Persons.FirstOrDefault(x => x.Id == id);

            this.LoadProperty(IdProperty, person.Id);
            this.LoadProperty(NameProperty, person.Name);

            this.JASService.DoSomething();
        }

        protected override void DataPortal_Insert()
        {
            PersonEntity personEntity = new PersonEntity()
            {
                Id = this.Id,
                Name = this.Name
            };

            this.Context.Persons.Add(personEntity);
            this.Context.SaveChanges();

            this.JASService.DoSomething();

            base.DataPortal_Insert();
        }

        protected override void DataPortal_Update()
        {
            var toBeUpdated = this.Context.Persons.FirstOrDefault(x => x.Id == this.Id);
            toBeUpdated.Name = this.Name;

            this.Context.SaveChanges();

            this.JASService.DoSomething();

            base.DataPortal_Update();
        }
    }
}
