using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.Demo.Datasource_Layer_Patterns.Row_Data_Gateway
{
    /// <summary>
    /// 人员入口类
    /// </summary>
    public class PersonGateway
    {
        private string lastName;
        private string firstName;
        private int numberOfDependents;

        public PersonGateway(string lastName, string firstName, int numberOfDependents)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.numberOfDependents = numberOfDependents;
        }

        public string GetLastName()
        {
            return this.lastName;
        }

        private void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public string GetFirstName()
        {
            return this.firstName;
        }

        private void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public int GetNumberOfDependents()
        {
            return this.numberOfDependents;
        }

        private void SetNumberOfDependents(int numberOfDependents)
        {
            this.numberOfDependents = numberOfDependents;
        }

        public void Update()
        {
             
        }

        public long Insert()
        {
            return 0;
        }

        public static PersonGateway Load(ResultSet rs)
        {
            return null;
        }
    }
}
