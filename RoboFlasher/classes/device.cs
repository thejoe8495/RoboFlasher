namespace RoboFlasher.classes {
    public class Device {
        public Device(string ip, string type, string serial) {
            IP = ip; Type = type; Serial = serial;
        }
        public string IP { get; set; }
        public string Type { get; set; }
        public string Serial { get; set; }
        public string Linetext {
            get {
                return IP + " " + Type;
            }
        }
    }
}
