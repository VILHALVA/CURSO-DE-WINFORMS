# CURSO DE WINFORMS
👨‍⚖️WINFORMS É UMA ABREVIAÇÃO PARA WINDOWS FORMS, QUE É UMA TECNOLOGIA DE INTERFACE GRÁFICA DO USUÁRIO (GUI) DESENVOLVIDA PELA MICROSOFT. ELA PERMITE A CRIAÇÃO DE APLICATIVOS DESKTOP PARA O SISTEMA OPERACIONAL WINDOWS UTILIZANDO A LINGUAGEM DE PROGRAMAÇÃO C#.

[![GitHub Repo stars](https://img.shields.io/badge/VILHALVA-GITHUB-03A9F4?logo=github)](https://github.com/VILHALVA) 
[![GitHub Repo stars](https://img.shields.io/badge/VEJA%20OS-VIDEOS-03A9F4?logo=youtube)](https://www.youtube.com/@vilhalva100/search?query=WINFORMS)
[![GitHub Repo stars](https://img.shields.io/badge/VEJA-DOCUMENTAÇÃO-03A9F4?logo=google)](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/?view=netdesktop-7.0) 
[![GitHub Repo stars](https://img.shields.io/badge/LINGUAGEM%20DE-PROGRAMAÇÃO-03A9F4?logo=github)](https://github.com/VILHALVA/CURSO-DE-C-SHARP) <br>

[![GitHub Repo stars](https://img.shields.io/badge/-PLAYLIST%20DO%20YOUTUBE-blueviolet)](https://youtube.com/playlist?list=PLAzlSdU-KYwVRRO6P9fn1LcoXSITIIev0&si=6wYU0EAxx_ml1kzv)

<img src="https://www.spec-india.com/wp-content/uploads/2023/05/winforms-logo.png" align="center" width="280"> <br>

![](https://i.imgur.com/waxVImv.png)

# CONCEITO:
WinForms é uma biblioteca de desenvolvimento de interface gráfica para aplicativos Windows usando a linguagem de programação C#. Vamos abordar alguns conceitos fundamentais e fornecer exemplos de código para ilustrar cada um deles.

## 1. **Formulários (Forms):**
   Um formulário é a base de qualquer aplicativo WinForms. Ele é a janela principal onde os controles são colocados. Aqui está um exemplo de código para criar um formulário simples:

   ```csharp
   using System;
   using System.Windows.Forms;

   public class MeuFormulario : Form
   {
       public MeuFormulario()
       {
           // Configurar propriedades do formulário
           this.Text = "Meu Formulário";
           this.Size = new System.Drawing.Size(300, 200);

           // Adicionar controles, manipuladores de eventos, etc.
           // Exemplo: Adicionar um botão
           Button meuBotao = new Button();
           meuBotao.Text = "Clique-me!";
           meuBotao.Click += MeuBotao_Click;

           this.Controls.Add(meuBotao);
       }

       private void MeuBotao_Click(object sender, EventArgs e)
       {
           MessageBox.Show("Você clicou no botão!");
       }

       static void Main()
       {
           Application.Run(new MeuFormulario());
       }
   }
   ```

   Neste exemplo, criamos um formulário (`MeuFormulario`) e adicionamos um botão a ele. Quando o botão é clicado, exibimos uma caixa de mensagem.

## 2. **Controles:**
   Controles são elementos visuais que você adiciona ao formulário para interagir com o usuário. Além do botão, há vários outros controles como caixas de texto, rótulos, listas, etc.

   ```csharp
   // Exemplo: Adicionar uma caixa de texto e um rótulo ao formulário
   TextBox minhaCaixaDeTexto = new TextBox();
   minhaCaixaDeTexto.Text = "Digite algo aqui";

   Label meuRotulo = new Label();
   meuRotulo.Text = "Meu Rótulo";

   this.Controls.Add(minhaCaixaDeTexto);
   this.Controls.Add(meuRotulo);
   ```

## 3. **Eventos:**
   Os eventos são ações que ocorrem durante a interação do usuário. No exemplo acima, usamos o evento `Click` para o botão. Aqui está outro exemplo:

   ```csharp
   // Exemplo: Adicionar um manipulador de eventos para o evento de alteração de texto da caixa de texto
   minhaCaixaDeTexto.TextChanged += MinhaCaixaDeTexto_TextChanged;

   private void MinhaCaixaDeTexto_TextChanged(object sender, EventArgs e)
   {
       meuRotulo.Text = "Texto alterado: " + minhaCaixaDeTexto.Text;
   }
   ```

   Este código atualiza o rótulo sempre que o texto na caixa de texto é alterado.

Estes são apenas conceitos iniciais. WinForms oferece uma ampla variedade de recursos para criar interfaces gráficas interativas. 