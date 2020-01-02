using System;

namespace RoboFlasher {
    static class extensions {

        public static int toUnixTimestamp(this DateTime value) {
            return (int)Math.Truncate((value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
        }
    }
}
