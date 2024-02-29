using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Circus.DB
{
    internal class DBConnection
    {
        public static Circus_SagdievaEntities circusDB = new Circus_SagdievaEntities();

        public static Worker loginedWorker;

        public static Worker selectedForEditWorker;

        public static Animal selectedForEditAnimal;
    }
}
