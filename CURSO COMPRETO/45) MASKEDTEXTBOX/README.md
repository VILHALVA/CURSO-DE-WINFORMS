# MASKEDTEXTBOX
Vamos criar um exemplo completo de uma aplicação Windows Forms em C# que utiliza o controle `MaskedTextBox`. Este exemplo demonstrará como configurar e utilizar este controle, além de lidar com a entrada de dados e eventos.

## Passos para criar o projeto:
1. **Abra o Visual Studio**.
2. **Crie um novo projeto**: Selecione "Windows Forms App (.NET Framework)".
3. **Adicione o código abaixo ao arquivo `Form1.cs`**.

## Código do Exemplo
```csharp
using System;
using System.Windows.Forms;

namespace MaskedTextBoxExample
{
    public partial class Form1 : Form
    {
        private MaskedTextBox maskedTextBox;
        private Label label;
        private Button submitButton;

        public Form1()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            // Configuração do MaskedTextBox
            maskedTextBox = new MaskedTextBox();
            maskedTextBox.Mask = "(999) 000-0000"; // Máscara para número de telefone
            maskedTextBox.Location = new System.Drawing.Point(20, 20);
            maskedTextBox.Width = 200;

            // Configuração do Label
            label = new Label();
            label.Location = new System.Drawing.Point(20, 60);
            label.Width = 200;

            // Configuração do Button
            submitButton = new Button();
            submitButton.Text = "Submit";
            submitButton.Location = new System.Drawing.Point(20, 100);
            submitButton.Click += new EventHandler(SubmitButton_Click);

            // Adiciona os controles ao formulário
            this.Controls.Add(maskedTextBox);
            this.Controls.Add(label);
            this.Controls.Add(submitButton);
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (maskedTextBox.MaskFull)
            {
                label.Text = "Telefone: " + maskedTextBox.Text;
            }
            else
            {
                label.Text = "Por favor, preencha todos os campos.";
            }
        }

        // Método principal
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
```

## Explicação do Código
1. **Configuração do Formulário**:
   - O formulário é configurado no construtor `Form1`.
   - `InitializeControls` é um método separado para configurar os controles no formulário.

2. **Configuração do `MaskedTextBox`**:
   - O `MaskedTextBox` é criado e configurado com a máscara `(999) 000-0000` para entrada de número de telefone.
   - A localização e a largura do controle são definidas.

3. **Configuração do `Label`**:
   - Um `Label` é criado para exibir mensagens ao usuário após a submissão.

4. **Configuração do `Button`**:
   - Um botão de submissão é criado e um event handler (`SubmitButton_Click`) é associado ao evento `Click`.

5. **Event Handler**:
   - O método `SubmitButton_Click` verifica se todos os caracteres obrigatórios foram inseridos usando a propriedade `MaskFull`.
   - Se a máscara estiver completa, exibe o valor no `Label`; caso contrário, solicita ao usuário que preencha todos os campos.

6. **Método `Main`**:
   - Configura e inicia a aplicação Windows Forms.

## Recursos Adicionais
- **Propriedade `Mask`**: Define o padrão de entrada usando caracteres de máscara, como `9` (dígito), `0` (dígito obrigatório), `L` (letra), etc.
- **Propriedade `MaskFull`**: Verifica se todos os caracteres obrigatórios foram inseridos.
- **Propriedade `PromptChar`**: Define o caractere de prompt exibido no lugar de entrada vazia.

Com este exemplo, você pode entender como usar o controle `MaskedTextBox` para garantir que a entrada do usuário siga um formato específico. Se precisar de mais funcionalidades ou de um layout mais complexo, você pode ajustar e expandir o código conforme necessário.