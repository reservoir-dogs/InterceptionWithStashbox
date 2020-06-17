using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Level1Service : ILevel1Service
    {
        private readonly ILevel2Service level2Service;

        public Level1Service(ILevel2Service level2Service)
        {
            this.level2Service = level2Service;
        }
    }
}
