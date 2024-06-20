# CONTEXTMENU
Para adicionar um menu de contexto (Context Menu) a um formulário em um aplicativo Windows Forms, você pode utilizar o controle `ContextMenuStrip`. Este controle permite exibir um menu de opções quando o usuário clica com o botão direito do mouse em um formulário ou em um controle específico. Abaixo estão os passos para criar e usar um `ContextMenuStrip` em um projeto Windows Forms:

## Criando e Utilizando um ContextMenuStrip em Windows Forms
1. **Criar o Projeto**

   - Abra o Visual Studio.
   - Crie um novo projeto de `Windows Forms App (.NET Framework)` com o nome `ExemploContextMenu`.

2. **Adicionar um ContextMenuStrip ao Formulário**

   - Na janela `Toolbox`, encontre o controle `ContextMenuStrip` e arraste-o para o formulário (`Form1`). Por padrão, ele não será visível no formulário, mas aparecerá na parte inferior da tela de design.

3. **Configurar o ContextMenuStrip**

   - Com o `ContextMenuStrip` selecionado no formulário, ajuste suas propriedades no painel `Properties`. Aqui estão algumas propriedades comuns que você pode configurar:

     - **Name**: Define o nome do controle (`contextMenuStripOpcoes` por exemplo).
     - **Items**: Adicione itens ao menu utilizando a propriedade `Items` ou diretamente no designer.
     - **Click Event**: Manipule o evento `Click` de cada item para responder às ações do usuário.

   Por exemplo, para um `ContextMenuStrip` com o nome `contextMenuStripOpcoes` e alguns itens:

   ```csharp
   this.contextMenuStripOpcoes.Name = "contextMenuStripOpcoes";
   
   // Adicionando itens diretamente no designer
   this.contextMenuStripOpcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
       new System.Windows.Forms.ToolStripMenuItem("Opção 1", null, Opcao1_Click),
       new System.Windows.Forms.ToolStripMenuItem("Opção 2", null, Opcao2_Click),
       new System.Windows.Forms.ToolStripMenuItem("Opção 3", null, Opcao3_Click)
   });
   ```

4. **Implementar os Métodos de Evento para Cada Opção**

   - Crie métodos separados para lidar com cada item do menu. Você pode criar esses métodos manualmente ou deixar o Visual Studio gerá-los automaticamente ao clicar duas vezes nos itens do menu no designer.

   ```csharp
   private void Opcao1_Click(object sender, EventArgs e)
   {
       MessageBox.Show("Opção 1 foi selecionada!");
   }

   private void Opcao2_Click(object sender, EventArgs e)
   {
       MessageBox.Show("Opção 2 foi selecionada!");
   }

   private void Opcao3_Click(object sender, EventArgs e)
   {
       MessageBox.Show("Opção 3 foi selecionada!");
   }
   ```

## Exemplo Completo
Aqui está o código completo do projeto:

**Form1.cs:**

```csharp
using System;
using System.Windows.Forms;

namespace ExemploContextMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Opcao1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opção 1 foi selecionada!");
        }

        private void Opcao2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opção 2 foi selecionada!");
        }

        private void Opcao3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opção 3 foi selecionada!");
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // Exibir o menu de contexto ao clicar com o botão direito do mouse
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStripOpcoes.Show(this, e.Location);
            }
        }
    }
}
```

**Form1.Designer.cs:**

Este arquivo é gerado automaticamente pelo Visual Studio e contém o código relacionado à criação e posicionamento dos controles.

```csharp
namespace ExemploContextMenu
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripOpcoes;

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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStripOpcoes = new System.Windows.Forms.ContextMenuStrip(this.components);
            
            // 
            // contextMenuStripOpcoes
            // 
            this.contextMenuStripOpcoes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                new System.Windows.Forms.ToolStripMenuItem("Opção 1", null, Opcao1_Click),
                new System.Windows.Forms.ToolStripMenuItem("Opção 2", null, Opcao2_Click),
                new System.Windows.Forms.ToolStripMenuItem("Opção 3", null, Opcao3_Click)
            });

            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Name = "Form1";
            this.Text = "Exemplo de ContextMenuStrip";
            this.ResumeLayout(false);
        }
    }
}
```

## Executando o Projeto
1. **Compilar e Executar**
   - Pressione `Ctrl + Shift + B` para compilar o projeto.
   - Pressione `Ctrl + F5` para executar o programa sem depuração.

2. **Interagir com a Aplicação**
   - Clique com o botão direito do mouse em qualquer lugar no formulário.
   - O menu de contexto `ContextMenuStrip` será exibido com as opções "Opção 1", "Opção 2" e "Opção 3".
   - Clique em qualquer uma das opções para exibir uma mensagem correspondente.

## Resumo
O `ContextMenuStrip` é um componente poderoso para adicionar menus contextuais em uma aplicação Windows Forms, permitindo que os usuários realizem ações específicas com facilidade ao clicar com o botão direito do mouse. Com os passos descritos acima, você aprendeu como configurar e utilizar um `ContextMenuStrip` em seu projeto, bem como implementar a lógica para responder às seleções dos usuários.