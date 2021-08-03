namespace DesafioFULL.Domain.Models
{
    public class Base
    {
        public int? Id { get; private set; }

        public Base(int? id)
        {
            Id = id;
        }

        public Base()
        {

        }

        public void setId(int id)
        {
            Id = id;
        }
    }
}
