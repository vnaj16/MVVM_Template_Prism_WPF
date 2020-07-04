using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Template_Prism_WPF.Models
{
    //Teléfono: Número, DNI, Persona
    public class Telefono : BindableBase
    {
		private string numero;

		public string Numero
		{
			get { return numero; }
			set { SetProperty(ref numero,value); }
		}

		private string dni;

		public string DNI
		{
			get { return dni; }
			set
			{
				SetProperty(ref dni, value);
			}
		}

		private Persona persona;

		public Persona Persona
		{
			get { return persona; }
			set {
				DNI = value.DNI;
				SetProperty(ref persona, value);
				persona.Telefonos.Add(this);
			}
		}

	}
}
