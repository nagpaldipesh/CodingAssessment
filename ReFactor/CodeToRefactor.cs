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

                    name = AppConstants.Bob;

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

        public string GetUserName(User user, string lastName) {
            if (lastName.Contains("test"))
                return user.Name;

            var userName = user.Name + " " + lastName;
            if (userName.Length > 255) {
                return userName.Substring(0, 255);
            }

            return userName;
        }

        public IEnumerable<User> GetUsersByName(string name, bool isUserOlderThanThirty) {
            if (isUserOlderThanThirty) {
                //DateTime thirtyYearsAgo = DateTime.UtcNow.AddYears(-30);
                DateTime thirtyYearsAgo = GetDateTime(30);
                return _users.Where(x => x.Name == name && x.DOB >= thirtyYearsAgo);
            }

            return _users.Where(x => x.Name == name);
        }

        private User GetUserByName(string name) {
            var randomNumber = new Random().Next(18, 85);
            //return new User(name, DateTime.UtcNow.AddYears(randomNumber * -1));
            return new User(name, GetDateTime(randomNumber));
        }

        private DateTime GetDateTime(int number) {
            return DateTime.Now.Subtract(new TimeSpan(number * 356));
        }
    }
}