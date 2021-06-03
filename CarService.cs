using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoService
{
    public class CarService
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;
        private string address;
        private string email;
        private string phone_number;
        public string Address { get { return address; } set { address = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Phone_Number { get { return phone_number; } set { phone_number = value; } }
        public int Id { get { return id; } set { id = value; } }
    }

    public class Staff : CarService
    {
        private string fio;
        private int work_experience;
        private string post;
        public Staff() { }
        public string Fio { get { return fio; } set { fio = value; } }
        public int Work_Experience { get { return work_experience; } set { work_experience = value; } }
        public string Post { get { return post; } set { post = value; } }
    }

    public class Service : CarService
    {
        private int price;
        private string appellations;
        public int Price { get { return price; } set { price = value; } }
        public string Appellations { get { return appellations; } set { appellations = value; } }
    }

    public class CarWash : Service
    {
        private string type;
        public CarWash() { }
        public string Type { get { return type; } set { type = value; } }
    }

    public class Repair : Service
    {
        private int queue;
        public int Queue { get { return queue; } set { queue = value; } }
    }

    public class PaintingWorks : Repair
    {
        private string type;
        public PaintingWorks() { }
        public string Type { get { return type; } set { type = value; } }
    }

    public class TireShop : Repair
    {
        private string type;
        public TireShop() { }
        public string Type { get { return type; } set { type = value; } }
    }

    public class Autoelectrics : Repair
    {
        private string type;
        public Autoelectrics() { }
        public string Type { get { return type; } set { type = value; } }
    }

    public class Motor : Repair
    {
        private string type;
        public Motor() { }
        public string Type { get { return type; } set { type = value; } }
    }
}
