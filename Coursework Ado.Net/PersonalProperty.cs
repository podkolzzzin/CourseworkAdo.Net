using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coursework_Ado.Net
{
    public enum PropertyType
    { 
        Contact,Address,Name,Birthdate,Unknown
    }
    public class PersonalProperty
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public PersonalProperty(string name, object value,PropertyType type)
        {
            Name = name;
            Value = value;
            Type = type;
        }
        public PersonalProperty(){}
        public PropertyType Type {get; set;}
    }
}
