# MAINLOOP
O método `Application.Run()` utilizado em aplicações Windows Forms serve para iniciar o loop principal de mensagens da aplicação. Esse loop principal é o que mantém a aplicação em execução e responde a eventos, como cliques de mouse e teclas pressionadas. Em Python, especialmente ao utilizar bibliotecas como Tkinter, a mesma funcionalidade é fornecida pelo método `mainloop()`, que mantém a janela aberta e processa eventos.

## Exemplo de `mainloop` em Tkinter
Aqui está um exemplo básico de uma aplicação Tkinter com um `Listbox` para demonstrar o uso de `mainloop`.

```python
import tkinter as tk

# Função que é chamada quando um item é selecionado no Listbox
def on_select(event):
    selected_indices = listbox.curselection()
    selected_items = [listbox.get(i) for i in selected_indices]
    print("Selected items:", selected_items)

# Criação da janela principal
root = tk.Tk()
root.title("Exemplo de Listbox em Tkinter")
root.geometry("300x200")

# Criação do Listbox e adição de itens
listbox = tk.Listbox(root, selectmode=tk.MULTIPLE)
items = ["Item 1", "Item 2", "Item 3", "Item 4"]
for item in items:
    listbox.insert(tk.END, item)

# Configuração do evento de seleção do Listbox
listbox.bind('<<ListboxSelect>>', on_select)

# Adição do Listbox ao layout
listbox.pack(padx=10, pady=10, fill=tk.BOTH, expand=True)

# Início do loop principal da aplicação
root.mainloop()
```

## Explicação do Código
1. **Função de Callback `on_select`**:
   - Define uma função que é chamada quando um item é selecionado no `Listbox`.
   - Recupera os índices dos itens selecionados e os itens correspondentes, e então imprime os itens selecionados.

2. **Criação da Janela Principal**:
   - Utiliza `tk.Tk()` para criar a janela principal da aplicação.
   - Define o título e o tamanho da janela.

3. **Criação do Listbox**:
   - Cria um `Listbox` com a opção de seleção múltipla (`selectmode=tk.MULTIPLE`).
   - Adiciona alguns itens ao `Listbox` usando um loop.

4. **Configuração do Evento de Seleção**:
   - Liga o evento de seleção do `Listbox` (`<<ListboxSelect>>`) à função de callback `on_select`.

5. **Adição do Listbox ao Layout**:
   - Utiliza o método `pack` para adicionar o `Listbox` ao layout da janela, permitindo que ele se expanda para preencher o espaço disponível.

6. **Início do Loop Principal**:
   - `root.mainloop()` inicia o loop principal da aplicação, mantendo a janela aberta e processando eventos.

## Comparação com Windows Forms
Enquanto o `Application.Run()` em Windows Forms é responsável por manter a aplicação em execução e processar eventos, o `mainloop()` em Tkinter desempenha o mesmo papel para aplicações Tkinter. Ambos métodos são essenciais para a criação de interfaces gráficas interativas, mantendo a janela da aplicação aberta e responsiva às interações do usuário.