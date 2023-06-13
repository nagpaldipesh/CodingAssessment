using System;

namespace ReFactor.Models {
    public class User {
            private DateTimeOffset under16 = DateTimeOffset.UtcNow.AddYears(-15);
            public string Name { get; private set; }
            public DateTimeOffset DOB { get; private set; }

            public User(string name, DateTime? dob = null) {
                Name = name;
                DOB = dob ?? under16.Date;
            }
    }
}
