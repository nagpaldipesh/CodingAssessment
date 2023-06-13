using ReFactor.Constants;
using ReFactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingAssessment.Refactor {

    public class UserService {
        /// <summary>
        /// List of Users
        /// </summary>
        private List<User> _users;

        public UserService() {
            _users = new List<User>();
        }
        /// <summary>
        /// Get List of users
        /// </summary>
        /// <param name="numberOfUsers"></param>
        /// <returns></returns>
        public List<User> GetUsers(int numberOfUsers) {
            for (int index = 0; index < numberOfUsers; index++) {
                try {
                    // Creates a random Name
                    string name = string.Empty;
                    var randomNumber = new Random().Next(0, 1);

                    name = randomNumber == 0 ? AppConstants.Bob : AppConstants.Betty;

                    // Adds new people to the list
                    _users.Add(GetUserByName(name));
                }
                catch (Exception) {
                    // Dont think this should ever happen
                    throw;
                }
            }
            return _users;
        }

        public string GetUserName(User p, string lastName) {
            if (lastName.Contains("test"))
                return p.Name;

            var userName = p.Name + " " + lastName;
            if (userName.Length > 255) {
                userName.Substring(0, 255);
            }

            return userName;
        }

        private IEnumerable<User> GetUsersByName(string name, bool isUserOlderThanThirty) {
            if (isUserOlderThanThirty) {
                DateTime thirtyYearsAgo = DateTime.UtcNow.AddYears(-30);
                return _users.Where(x => x.Name == name && x.DOB >= thirtyYearsAgo);
            }

            return _users.Where(x => x.Name == name);
        }

        private User GetUserByName(string name) {
            var randomNumber = new Random().Next(18, 85);
            return new User(name, DateTime.UtcNow.AddYears(randomNumber * -1));
        }
    }
}