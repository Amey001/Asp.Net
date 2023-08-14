namespace BOL
{
    public enum ROOM
    {
        ICU,SPECIAL,GENERL
    }

    public class Patient
    {
        public int ? pid {  get; set; }  
        public string ? pname { get; set; }
        public string ? disease { get; set; }
        public ROOM room { get; set; }
        public DateOnly  admitdate { get; set; }

        public Patient() { }

        public Patient(int pid,String pname,string disease,string room,DateOnly date)
        { 
            this.pid = pid;
            this.pname = pname;
            this.disease = disease;
            this.room=Enum.Parse<ROOM>(room);  
            this.admitdate=date;    
        }

        public Patient(String pname, string disease, string room, DateOnly date)
        {
            this.pname = pname;
            this.disease = disease;
            this.room = Enum.Parse<ROOM>(room);
            this.admitdate = date;
        }
    }
}