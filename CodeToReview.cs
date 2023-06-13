using System;
using System.Collegctions.Generic;
using System.Linq;

namespace Utility.Valocity.ProfileHelper {

    //Model should not be part of same namespace.
    //People is not descriptive. Please rename it to User. 
    public class People {
        // What do you meant by Under16 here? How it's value should be evaluated?
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
        public string Name { get; private set; }
        public DateTimeOffset DOB { get; private set; }
        //Both constructors can be combined together. dob parameter can be converted into optional parameter which have the default value like:
        //public People(string name, DateTime dob = Under16.Date) { }
        public People(string name) : this(name, Under16.Date) { }
        public People(string name, DateTime dob) {
            Name = name;
            DOB = dob;
        }
    }

    // BirthingUnit is not explanatory.
    public class BirthingUnit {

        // Summary makes no sense. Please provide a explanatory summary
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        private List<People> _people;

        public BirthingUnit() {
            _people = new List<People>();
        }

        /// <summary>
        /// GetPeoples
        /// </summary>
        /// <param name="j"></param>
        /// <returns>List<object></returns>

        // What i means here? Could you please rename it to some descriptive name
        // The method name GetPeople not descriptive  and update the summary as well as

        public List<People> GetPeople(int i) {
            // The variable names "i" and "j" are not descriptive.
            for (int j = 0; j < i; j++) {
                try {
                    // Creates a randon Name
                    string name = string.Empty;
                    var random = new Random();

                    // Convert if else into ternary statement for more redability
                    if (random.Next(0, 1) == 0) {
                        // Create constant class and move these constant values there. So, it can be used across multiple places
                        name = "Bob";
                    }
                    else {
                        name = "Betty";
                    }

                    // new People(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0))
                    // Above given codes makes code more complex. Please create a new method which will return the Person object by name

                    // Adds new people to the list
                    _people.Add(new People(name, DateTime.UtcNow.Subtract(new TimeSpan(random.Next(18, 85) * 356, 0, 0, 0))));
                }
                catch (Exception e) {
                    // Dont think this should ever happen

                    // throwing a new exception is not good approach. Exception details and stack trace is very usefull for the bug fix
                    throw new Exception("Something failed in user creation");
                }
            }
            return _people;
        }

        // Please rename it to GetPeopleByName
        // Do not give constant name in Where condition. Better to take name from Input. Like:
        //private IEnumerable<People> GetPeopleByName(string name, bool isOlderThanThirty) {
        //    return isOlderThanThirty ? _people.Where(x => x.Name == name && x.DOB >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.Name == name);
        //}

        private IEnumerable<People> GetBobs(bool olderThan30) {

            // new TimeSpan(30 * 356, 0, 0, 0))
            // If I am not wrong, you might want to get 30 Years back Date. If Yes, Why you have used 356? 
            //  And it can be replace by below code:
            //  DateTime.UtcNow.AddYears(-30)
            return olderThan30 ? _people.Where(x => x.Name == "Bob" && x.DOB >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.Name == "Bob");
        }

        // Why method name is GetMarried? 
        // p is not descriptive
        public string GetMarried(People p, string lastName) {
            if (lastName.Contains("test"))
                return p.Name;

            // Here what you want to achieve?
            // Let's suppose p.Name is 'Dipesh' and lastName is 'Nagpal'
            //(p.Name.Length + lastName).Length => (6 + "Nagpal").Length => 7
            // Is above behavior is correct?

            if ((p.Name.Length + lastName).Length > 255) {
                (p.Name + " " + lastName).Substring(0, 255);
            }

            return p.Name + " " + lastName;
        }
    }
}