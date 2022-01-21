using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCrudAmedia.Helpers
{
    public static class TablaGeneral
    {
        public enum CustomClaimIdentity
        {
            Nombre,
            Apellido,
            CuentaID
        }

        public struct RolesUsuario
        {
            public const int Admin = 1;
            public const int Cliente = 2;
        }

        public struct Acciones
        {
            public const string ALTA = "A";
            public const string BAJA = "B";
            public const string MODIFICACION = "M";
        }

    }
}
