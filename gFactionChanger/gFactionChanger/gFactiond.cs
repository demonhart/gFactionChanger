
namespace gFactionChanger
{
    class gFactiond
    {
        private FormController frmControl = new FormController();
        private Reader reader = new Reader();
        private Info info = new Info();

        public FormController getFormController()
        {
            return this.frmControl;
        }

        public Reader getReader()
        {
            return this.reader;
        }

        public Info getInfo()
        {
            return this.info;
        }
    }
}
