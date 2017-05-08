using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.LocalDB.ViewModel;

namespace XF.LocalDB.View.Aluno
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NovoView : ContentPage
    {
        #region atributos
        AlunoViewModel vmAluno;
        #endregion

        public NovoView()
        {
            InitializeComponent();
        }

        private int alunoId = 0;
        public NovoView(int Id)
        {
            InitializeComponent();

            this.alunoId = Id;

        }

        protected override void OnAppearing()
        {
            if (alunoId != 0)
                vmAluno = new AlunoViewModel(alunoId);
            else
                vmAluno = new AlunoViewModel();
            BindingContext = vmAluno;

            base.OnAppearing();

        }

        public void OnSalvar(object sender, EventArgs args)
        {
            XF.LocalDB.Model.Aluno aluno = new XF.LocalDB.Model.Aluno()
            {
                Nome = txtNome.Text,
                RM = txtRM.Text,
                Email = txtEmail.Text,
                Aprovado = IsAprovado.IsToggled,
                Id = alunoId
            };
            Limpar();
            App.AlunoModel.SalvarAluno(aluno);
            Navigation.PopAsync();
        }

        public void OnCancelar(object sender, EventArgs args)
        {
            Limpar();
            Navigation.PopAsync();
        }

        private void Limpar()
        {
            txtNome.Text = txtRM.Text = txtEmail.Text = string.Empty;
            IsAprovado.IsToggled = false;
        }

    }
}
