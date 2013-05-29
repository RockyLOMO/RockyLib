using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Runtime.Serialization;

namespace InfrastructureService.Model.User
{
    /// <summary>
    /// ��ʾ�û������Ϣ
    /// </summary>
    [DataContract]
    public sealed class SSOIdentity : IIdentity
    {
        #region ʵ��IIdentity�ӿ�
        /// <summary>
        /// ��ȡ��֤����
        /// </summary>
        public string AuthenticationType
        {
            get { return "InfrastructureService.SSO"; }
        }

        /// <summary>
        /// �����û��Ƿ񾭹���֤
        /// </summary>
        [DataMember]
        public bool IsAuthenticated { get; set; }

        string IIdentity.Name
        {
            get { return this.UserName; }
        }
        #endregion

        /// <summary>
        /// �û�ID
        /// </summary>
        [DataMember]
        public Guid UserID { get; set; }
        /// <summary>
        /// ��¼��
        /// </summary>
        [DataMember]
        public string UserName { get; set; }
        /// <summary>
        /// ��¼����
        /// </summary>
        [DataMember]
        public string Token { get; set; }
        /// <summary>
        /// �ỰID
        /// </summary>
        [DataMember]
        public string SessionID { get; set; }
        /// <summary>
        /// ���ư䷢ʱ��
        /// </summary>
        [DataMember]
        public DateTime IssueDate { get; set; }
    }
}