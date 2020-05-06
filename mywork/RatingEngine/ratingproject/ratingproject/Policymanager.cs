using System;
using System.Collections.Generic;
using System.Text;

namespace ratingproject
{
    public abstract class Policymanager
    {
        public void Log( string message) {

            Console.WriteLine(message);
            
        }
        public abstract void Rate(LifePolicy lf);

    }
}
