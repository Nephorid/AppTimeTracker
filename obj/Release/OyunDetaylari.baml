   M S B A M L   `   `   `  ���� I  EAppTimeTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AppTimeTrackerAppTimeTracker  "    AppTimeTracker.OyunDetaylari   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .localclr-namespace:AppTimeTracker     ���#080024.���   � RowDefinitions  �� $
��Auto ��� $��* �.+��� -    ��Name$ GameNameTextBlock��$��0��$��24(�$
��Bold"�$��20,20,20,20q�
��������� -   $ TimePlayedTextBlock��$��0��$��16(�$��SemiBold"�$
��Left=�
�������$	��Top=�$��20,70,20,20q��� -    ��Name$ PlayGameButton��$
��Oyna��$��1��
�������$��15,20,10,10q�$��14(�$��Medium"�$
��Left=�$	��Top=�����  �� 
TargetType" ��.���  �� Property � �� �� Value �#39385D��  �@�Cursor$
 Hand�� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � �� �#3A3952���� 	 �� 
TargetType"	 ��.R��� $	��100��$��30��
 �� CornerRadius$
 11��#��z��._��� $��Center=�$��Center=�