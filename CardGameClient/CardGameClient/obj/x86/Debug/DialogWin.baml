   M S B A M L   `   `   `  ����I  ECardGameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CardGameClientCardGameClient  5   	       CardGameClient.DialogWin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   +dcclr-namespace:CardGameClient     5   	   -   5        $��	DialogWnd��5   +     � Title$  Avalon: Battles for Glory��6	    � 
ResizeMode$ NoResize=�6<    � UseLayoutRounding .  J� SnapsToDevicePixels .  � ShowInTaskbar .   � WindowStartupLocation$ CenterOwner=�6�   $	��768��6�   $
��1024��6�   $	��768��6�   $
��1024��6�    � Cursor$1 +/CardGameClient;component/Images/cursor.cur��6�    � WindowStyle$
 None=�60   � WindowState$ 	Maximized=�6C  	 � AllowsTransparency	 . ���	#AA000000.��5      � .+�5   
   � $	��230��6   $	��600��6   $��0, -35, 0, 35q�6)   .+�5      �� -   5        $��TextInfo��5      $��14(�6(   $��Verdana)�66   $��0, 0, 0, 35q�6K   $��Center=�6`   $N��HУстанавливается соединение. Ожидайте...��6}   
 �� TextAlignment$
 Center=�6�   $��Center=�6�   
�������$
��Wrap=�6�   5	         CardGameClient.StyledBtn  5
      -   5          Name$ 	AcceptBtn��5
         CardGameClient.StyledBtn   MouseUp$ AcceptBtnOnly_MouseUp��6�   $
��Left=�6.      Text$
 Да��6I   $��Bottom=�6S   $��34��6n   $	��135��6z   $��
157,0,0,35q�6�   $y�Hidden=�6�   6�     5      -   5        $ AcceptBtnOnly��5      $ AcceptBtnOnly_MouseUp��6�   $��Center=�62   $
 ОК��6O   $��Bottom=�6Y   $��34��6t   $	��135��6�   $��0,0,0,35q�6�   $y�Hidden=�6�   6�     5      -   5        $ 	CancelBtn��5      $ Image_MouseUp��6�   $��Right=�6.   $ Отмена��6J   $��Bottom=�6X   $��34��6s   $	��135��6   $��
0,0,157,35q�6�   $y�Hidden=�6�   6�   ��5      �� 5       �� ImageSource$3 -/CardGameClient;component/Images/popup_bg.png��6   5      5      5      