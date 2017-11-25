using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{

    namespace Education {

        public abstract class EducationPlace
        {
            protected string EdType { get; set; }
            public string name { get; set; }
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
        }
        public class Kindergarden : EducationPlace
        {
            Kindergarden()
            { EdType = "Kindergarden: "; }
            public string className { get; set; }
        }
        public class School : EducationPlace
        {
            School()
            { EdType = "School: "; }
            public string className { get; set; }
        }

        public class College : EducationPlace
        {
            College()
            { EdType = "College: "; }
            public string faculty { get; set; }
            public string speciality { get; set; }
        }

        public class University : EducationPlace
        {
            University()
            { EdType = "University: "; }
            public string faculty { get; set; }
            public string speciality { get; set; }
        }

    }



    namespace PersonProperties {

        public enum Sex
        {
            male,
            female,
            unknown
        }
        public enum SocialStatus
        {
            individual,
            entity,
            unknown
        }

        public enum Capability {
            capable,
            incapable,
            unknown
        }

        public enum DisabledGroup {
            none,
            fisrtGroup,
            secondGroup,
            thirdGroup,
            unknown
        }

    }



    


    public abstract class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public string ID { get; set; }
        public DateTime birthDate { get; set; }
        public PersonProperties.Sex sex { get; set; }
        public PersonProperties.SocialStatus socialStatus { get; set; }
        public List<Adult> parents { get; set; }

        public Person(string name, PersonProperties.Sex sex) : this(name, 0, "no data", DateTime.Now, sex, PersonProperties.SocialStatus.unknown) { }

        public Person(string name, int age, string ID, DateTime birthDate, PersonProperties.Sex sex, PersonProperties.SocialStatus socialStatus) {
            this.name = name;
            this.age = age;
            this.ID = ID;
            this.birthDate = birthDate;
            this.sex = sex;
            this.socialStatus = socialStatus;
        }

        public void showPerson()
        {
            Console.WriteLine("Имя: {0}", name);
            Console.WriteLine("Age: {0}", age);
            Console.WriteLine("ID: {0}", ID);
            Console.WriteLine("birthDate: {0}", birthDate.ToLongDateString());
            Console.WriteLine("Sex: {0}", sex);
            Console.WriteLine("Social Status: {0}", socialStatus);

        }

    }

    public class Adult : Person
    {
        public bool driverLicense { get; set; }


        public List<Child> children { get; set; }

        
        public List<Education.EducationPlace> education { get; set; }

        public Adult() : this ("no name", PersonProperties.Sex.unknown) { }
        public Adult(string name, PersonProperties.Sex sex) : base (name, sex) { }
        public Adult(string name, int age, string ID, DateTime birthDate, PersonProperties.Sex sex, PersonProperties.SocialStatus socialStatus) 
            : base (name, age, ID, birthDate, sex, socialStatus) {}

        public static bool operator ==(Adult a, Adult b)
        {
            return (a.age == b.age);
        }

        public static bool operator !=(Adult a, Adult b)
        {
            return (a.age != b.age);
        }

    }

    public class Child : Person
    {
        public List<Education.EducationPlace> education { get; set; }
        public Child() : this ("no name", PersonProperties.Sex.unknown) { }
        public Child(string name, PersonProperties.Sex sex) : base (name, sex) { }
        public Child(string name, int age, string ID, DateTime birthDate, PersonProperties.Sex sex, PersonProperties.SocialStatus socialStatus)
            : base(name, age, ID, birthDate, sex, socialStatus) { }
    }

    public class Disabled: Adult
    {
        public double allowance { get; set; }
        public PersonProperties.DisabledGroup disabledGroup { get; set; }

        public Disabled() : this ("no name", PersonProperties.Sex.unknown) { }
        public Disabled(string name, PersonProperties.Sex sex) : base (name, sex) { }
        public Disabled(string name, int age, string ID, DateTime birthDate, PersonProperties.Sex sex, PersonProperties.SocialStatus socialStatus)
            : base(name, age, ID, birthDate, sex, socialStatus) { }
    }
}
