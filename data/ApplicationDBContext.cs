 

namespace rest_two.data
{
    
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContext dbContext) : base(dbContext){
            
        }
    }
}