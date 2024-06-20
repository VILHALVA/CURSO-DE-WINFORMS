# PRIMEIRA APLICAÇÃO
## Objetivo
Criar a primeira aplicação Windows Forms que inclui um formulário simples com um botão e um rótulo (label).

## Passos
1. **Criar o Projeto**

   - Abra o Visual Studio.
   - No menu principal, clique em `File` > `New` > `Project...`.
   - Selecione `Windows Forms App (.NET Framework)` no painel esquerdo.
   - Dê um nome ao projeto, por exemplo, `PrimeiraAplicacao`, e clique em `Create`.

2. **Adicionar Controles ao Formulário**

   - Na janela `Toolbox`, arraste os seguintes controles para o formulário (`Form1`):
     - Um `Label` (rótulo).
     - Um `Button` (botão).

3. **Configurar os Controles**

   - Selecione o `Label` e altere as seguintes propriedades no painel `Properties`:
     - `Name`: `labelMensagem`
     - `Text`: ``
     - `AutoSize`: `True`
   
   - Selecione o `Button` e altere as seguintes propriedades:
     - `Name`: `buttonMostrarMensagem`
     - `Text`: `Mostrar Mensagem`

4. **Adicionar Evento de Clique ao Botão**

   - Dê um duplo clique no botão `buttonMostrarMensagem` para gerar o método do evento de clique no arquivo `Form1.cs`.

5. **Implementar a Lógica no Evento de Clique**

   - No arquivo `Form1.cs`, adicione o seguinte código no método `buttonMostrarMensagem_Click`:

```csharp
using System;
using System.Windows.Forms;

namespace PrimeiraAplicacao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonMostrarMensagem_Click(object sender, EventArgs e)
        {
            labelMensagem.Text = "Olá, Mundo!";
        }
    }
}
```

### Código Completo
**Form1.cs:**

```csharp
using System;
using System.Windows.Forms;

namespace PrimeiraAplicacao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonMostrarMensagem_Click(object sender, EventArgs e)
        {
            labelMensagem.Text = "Olá, Mundo!";
        }
    }
}
```

**Form1.Designer.cs:**

Esse arquivo é gerado automaticamente pelo Visual Studio quando você adiciona controles ao formulário. Abaixo está um exemplo de como ele deve parecer com os controles `Label` e `Button` adicionados.

```csharp
namespace PrimeiraAplicacao
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelMensagem;
        private System.Windows.Forms.Button buttonMostrarMensagem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelMensagem = new System.Windows.Forms.Label();
            this.buttonMostrarMensagem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            
            // 
            // labelMensagem
            // 
            this.labelMensagem.AutoSize = true;
            this.labelMensagem.Location = new System.Drawing.Point(100, 50);
            this.labelMensagem.Name = "labelMensagem";
            this.labelMensagem.Size = new System.Drawing.Size(0, 13);
            this.labelMensagem.TabIndex = 0;

            // 
            // buttonMostrarMensagem
            // 
            this.buttonMostrarMensagem.Location = new System.Drawing.Point(100, 100);
            this.buttonMostrarMensagem.Name = "buttonMostrarMensagem";
            this.buttonMostrarMensagem.Size = new System.Drawing.Size(100, 23);
            this.buttonMostrarMensagem.TabIndex = 1;
            this.buttonMostrarMensagem.Text = "Mostrar Mensagem";
            this.buttonMostrarMensagem.UseVisualStyleBackColor = true;
            this.buttonMostrarMensagem.Click += new System.EventHandler(this.buttonMostrarMensagem_Click);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonMostrarMensagem);
            this.Controls.Add(this.labelMensagem);
            this.Name = "Form1";
            this.Text = "Primeira Aplicação";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
```

## Executando o Projeto
1. **Compilar e Executar**
   - Pressione `Ctrl + Shift + B` para compilar o projeto.
   - Pressione `Ctrl + F5` para executar o programa sem depuração.

2. **Interagir com a Aplicação**
   - Clique no botão "Mostrar Mensagem".
   - O rótulo (`Label`) deve exibir "Olá, Mundo!".

## Resumo
Neste exemplo, criamos um projeto Windows Forms, adicionamos um rótulo e um botão ao formulário, e configuramos o botão para atualizar o texto do rótulo quando clicado. Este é um exemplo básico, mas demonstra os conceitos fundamentais do desenvolvimento com Windows Forms.