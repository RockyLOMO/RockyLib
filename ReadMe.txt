1.http://www.alexa.com

2.��ν�����Ż��������ǽ����ڲ��ԵĻ���֮�ϣ�ACT Test�ǱȽ�ˬ�Ĳ��Թ��ߣ���Load Runner���㣬��Web Stressֱ�ۣ�֧�ֽű���̺�¼�Ƶ�½��ע��ȫ���̡� 
  �����Ż���Ҫ���жԱȲ��ԣ��������е��������ݡ� 
  ���ԣ�������Ϊ������ѹ�����ԣ��Ż��ǿ���������û������֧�֣��ǲ��Ͻ��ġ�

3.WCF֤����֤:
����ˣ�
	makecert -n "CN=azure.xineworld.com" -pe -sr localmachine -ss My -a sha1 -r -sky exchange -sp "Microsoft RSA SChannel Cryptographic Provider" -sy 12
	C:\Documents and Settings\All Users\Application Data\Microsoft\Crypto\RSA\MachineKeys
	C:\ProgramData\Microsoft\Crypto\RSA\MachineKeys
	http://msdn.microsoft.com/zh-cn/library/bfsktky3.aspx
	http://support.microsoft.com/kb/901183/zh-cn
�ͻ��ˣ�
	certmgr -add -r localmachine -s My -c -n azure.xineworld.com -s TrustedPeople
	CertMgr.msc

4.
1) ��װService: C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe D:\Delicious\WinServices\Delicious.WinServices.exe
2) ж��Service: C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe /u D:\Delicious\WinServices\Delicious.WinServices.exe
3) ����Service: net start "��������"

5. 
  a. Https�������ӻ�ȡ���⣻
  b. Git��Ŀ��վ���ɣ�
  c. Ӳ�̷�����Զ�̲ٿأ�