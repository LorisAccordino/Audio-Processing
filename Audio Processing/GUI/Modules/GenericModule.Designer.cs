namespace AudioProcessing.GUI.Modules
{
    partial class GenericModule
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // GenericModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Name = "GenericModule";
            ResumeLayout(false);
        }
        #endregion

        #region Manually written code

        /// <summary>
        /// Initializes the events when called
        /// </summary>
        public virtual void InitializeEvents() { }

        /// <summary>
        /// Enable/disable and reset the component
        /// </summary>
        /// /// <param name="enabled">Enable or disable the control after resetting</param>
        public virtual void ResetComponent(bool enabled)
        {
            Enabled = enabled;
        }

        #endregion
    }
}
