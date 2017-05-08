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

            MessagingCenter.Subscribe<AlunoViewModel>(vmAluno, "FecharTela", (msg) =>
            {
                Navigation.PopAsync();
            });

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            MessagingCenter.Unsubscribe<AlunoViewModel>(vmAluno, "FecharTela");
        }

    }
}
