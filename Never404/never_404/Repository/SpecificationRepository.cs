using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace never_404.Repository
{
    public class SpecificationRepository
    {
        private static SpecificationRepository specificationRepo;

        private SpecificationRepository()
        {

        }

        public static SpecificationRepository GetRepository()
        {
            if (specificationRepo == null)
            {
                specificationRepo = new SpecificationRepository();
            }
            return specificationRepo;
        }
    }
}
