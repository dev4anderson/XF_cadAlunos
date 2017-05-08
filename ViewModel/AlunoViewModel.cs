using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XF.LocalDB.Model;

namespace XF.LocalDB.ViewModel
{
    public class AlunoViewModel
    {
        #region Atributos
        public Aluno alunoSelecionado;
        private int alunoID;
        private Aluno aluno;
        #endregion

        public AlunoViewModel()
        {
            OnNovoCommand = new Command(() =>
            {
                MessagingCenter.Send<AlunoViewModel>(this, "NovoAluno");
            });
        }

        public AlunoViewModel(int alunoID)
        {
            aluno = App.AlunoModel.GetAluno(alunoID);
            Nome = aluno.Nome;
            Email = aluno.Email;
            RM = aluno.RM;
            Aprovado = aluno.Aprovado;
        }

        #region Propriedades
        public string RM { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public bool Aprovado { get; set; }
        public ICommand OnNovoCommand { get; set; }

        public List<Aluno> Alunos
        {
            get
            {
                return App.AlunoModel.GetAlunos().ToList();
            }
        }

        public Aluno AlunoSelecionado
        {
            get
            {
                return alunoSelecionado;
            }
            set
            {
                alunoSelecionado = value;
                if (alunoSelecionado != null)
                {
                    this.Id = alunoSelecionado.Id;
                    this.Nome = alunoSelecionado.Nome;
                    MessagingCenter.Send<AlunoViewModel>(this, "AlunoSelecionado");
                }

            }
        }

        #endregion
    }
}
