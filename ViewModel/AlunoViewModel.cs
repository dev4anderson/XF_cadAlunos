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
        public Aluno alunoModificado;
        private int alunoID;
        private Aluno aluno;
        #endregion

        public AlunoViewModel()
        {
            OnNovoCommand = new Command(() =>
            {
                MessagingCenter.Send<AlunoViewModel>(this, "NovoAluno");
            });

            OnSalvarCommand = new Command(() =>
            {
                alunoModificado = new Aluno();
                alunoModificado.Nome = Nome;
                alunoModificado.RM = RM;
                alunoModificado.Email = Email;
                alunoModificado.Aprovado = Aprovado;
                Limpar();
                App.AlunoModel.SalvarAluno(alunoModificado);
                MessagingCenter.Send<AlunoViewModel>(this, "FecharTela");
            });
        }

        public AlunoViewModel(int alunoID)
        {
            aluno = App.AlunoModel.GetAluno(alunoID);
            Nome = aluno.Nome;
            Email = aluno.Email;
            RM = aluno.RM;
            Aprovado = aluno.Aprovado;
            Id = alunoID;

            OnSalvarCommand = new Command(() =>
            {
                alunoModificado = new Aluno();
                alunoModificado.Nome = Nome;
                alunoModificado.RM = RM;
                alunoModificado.Email = Email;
                alunoModificado.Aprovado = Aprovado;
                alunoModificado.Id = Id;
                Limpar();
                App.AlunoModel.SalvarAluno(alunoModificado);
                MessagingCenter.Send<AlunoViewModel>(this, "FecharTela");
            });

        }

        private void Limpar()
        {
            Nome = string.Empty;
            RM = string.Empty;
            Email = string.Empty;
            Aprovado = false;
        }

        #region Propriedades
        public string RM { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public bool Aprovado { get; set; }
        public ICommand OnNovoCommand { get; set; }
        public ICommand OnSalvarCommand { get; set; }

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
