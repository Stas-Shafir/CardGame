   M S B A M L   `   `   `  ����I  ECardGameClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CardGameClientCardGameClient  5   	   #    CardGameClient.CardPackWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   +dcclr-namespace:CardGameClient     5   	   -   5        $��CardPackWnd��5   +     � Title$  Avalon: Battles for Glory��6	    � 
ResizeMode$ NoResize=�6>    � ShowInTaskbar .   � WindowStartupLocation$ CenterScreen=�6j   $	��768��6�   $
��1024��6�   $	��768��6�   $
��1024��6�    � Cursor$1 +/CardGameClient;component/Images/cursor.cur��6�    � WindowStyle$
 None=�6�    � WindowState$ 	Maximized=�6   � AllowsTransparency . ���	#C6000000.��5      � $	��311��6   $	��588��6   $	��311��6*   $	��588��67   $	��311��6C   $	��588��6S    � UseLayoutRounding . 	 J� SnapsToDevicePixels	 . ��5   
   �� 5      
 �� ImageSource$:
 4/CardGameClient;component/Images/newCardWnd_wide.png��6    �� BitmapScalingMode$
 Fant=�6\   .+�5
      �� $��Новые карты!��6    . 	 . $��Center=�6b   $��Center=�6�   $��0,17,0,0q�6�   $��16(�6�   $,��&Fonts/MyriadPro-Regular.otf#Myriad Pro)�6�   $	��Top=�6�   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 0Q�6#      RenderingBias$ Quality=�62      	Direction$	 330Q�6J      ShadowDepth$ 3Q�6Z   5      �� 5   
   -   5        $��CardNameLabel1��5   �   $��Воин��6    . 	 . $��Center=�6S   $��Center=�6w   $��
0,39,300,0q�6�   $��16(�6�   $,��&Fonts/MyriadPro-Regular.otf#Myriad Pro)�6�   $	��Top=�6   
������� 5        5      $ 0Q�6#   $ Quality=�62   $	 330Q�6J   $ 3Q�6Z   5         CardGameClient.CardPlace  5   
   -   5          Name$ NewCardPlace1��5         
IsMineCard .    inGame .  $	��131��6O   $	��169��6[   $��0,65,300,77q�6h   $��Center=�6}   $��Center=�6�   {�.  6�   �� 5   
   -   5        $��CardNameLabel2��5   �   $��Лучник��6    . 	 . $��Center=�6U   $��Center=�6y   $��0,39,0,0q�6�   $��16(�6�   $,��&Fonts/MyriadPro-Regular.otf#Myriad Pro)�6�   $	��Top=�6   
������� 5        5      $ 0Q�6#   $ Quality=�62   $	 330Q�6J   $ 3Q�6Z   5        5   
   -   5        $ NewCardPlace2��5       .  .  $	��131��6O   $	��169��6[   $��	0,65,0,77q�6h   $��Center=�6{   $��Center=�6�   {�.  6�   �� 5   
   -   5        $��CardNameLabel3��5   �   $��Маг��6    . 	 . $��Center=�6R   $��Center=�6v   $��
300,39,0,0q�6�   $��16(�6�   $,��&Fonts/MyriadPro-Regular.otf#Myriad Pro)�6�   $	��Top=�6�   
������� 5         5!      $ 0Q�6#   $ Quality=�62   $	 330Q�6J   $ 3Q�6Z   5#        5$   
   -   5        $ NewCardPlace3��5$       .  .  $	��131��6O   $	��169��6[   $��300,65,0,77q�6h   $��Center=�6}   $��Center=�6�   {�.  6�      CardGameClient.StyledBtn  5&   
      CardGameClient.StyledBtn   MouseUp$ Image_MouseUp��6�   $��Center=�6      Text$ Принять��64   $��Bottom=�6C   $��34��6^   $	��135��6j   $��0,0,0,32q�6v   6�   5'      5(      