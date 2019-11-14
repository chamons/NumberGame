using Foundation;
using System;
using UIKit;

namespace NumberGame
{
	public partial class ViewController : UIViewController
	{
		public ViewController (IntPtr handle) : base (handle)
		{
		}

		Random Random;
		int PickedNumber;
		UITextView OutputText;
		UITextView GuessEntry;
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Random = new Random ();
			CreateUI ();
			StartGame ();
		}

		void StartGame ()
		{
			PickedNumber = Random.Next (0, 99);
			Print ("I've chosen a number.");
		}

		void Guess (int guess)
		{
			if (guess > PickedNumber) {
				Print ("Too High!");
			}
			else if (guess < PickedNumber) {
				Print ("Too Low!");
			}
			else {
				Print ("Correct!");
				StartGame ();
			}
		}

		void Print (string s)
		{
			OutputText.Text = OutputText.Text + s + "\n";
		}

		void OnButtonPress (object sender, EventArgs e)
		{
			if (int.TryParse (GuessEntry.Text, out int guess)) {
				Guess (guess);
			}
			else {
				Print ("Invalid Guess");
			}
		}

		void CreateUI ()
		{
			UIStackView stack = new UIStackView {
				Axis = UILayoutConstraintAxis.Vertical,
				Distribution = UIStackViewDistribution.EqualSpacing,
				Alignment = UIStackViewAlignment.Fill,
				Spacing = 20,
				TranslatesAutoresizingMaskIntoConstraints = false
			};
			View.AddSubview (stack);

			stack.CenterXAnchor.ConstraintEqualTo (View.CenterXAnchor).Active = true;
			stack.CenterYAnchor.ConstraintEqualTo (View.CenterYAnchor).Active = true;

			OutputText = new UITextView {
				TextAlignment = UITextAlignment.Natural,
				Editable = false
			};
			OutputText.Layer.BorderColor = UIColor.Black.CGColor;
			OutputText.Layer.BorderWidth = 2;
			stack.AddArrangedSubview (OutputText);

			OutputText.WidthAnchor.ConstraintEqualTo (View.WidthAnchor, 0.85f).Active = true;
			OutputText.HeightAnchor.ConstraintEqualTo (View.HeightAnchor, 0.25f).Active = true;

			GuessEntry = new UITextView {
				Editable = true,
				TextColor = UIColor.Blue,
				BackgroundColor = UIColor.LightGray
			};
			GuessEntry.Layer.BorderColor = UIColor.Black.CGColor;
			GuessEntry.Layer.BorderWidth = 2;

			stack.AddArrangedSubview (GuessEntry);

			GuessEntry.WidthAnchor.ConstraintEqualTo (View.WidthAnchor, 0.85f).Active = true;
			GuessEntry.HeightAnchor.ConstraintEqualTo (View.HeightAnchor, 0.03f).Active = true;

			UIButton button = UIButton.FromType (UIButtonType.RoundedRect);
			button.SetTitle ("Guess", UIControlState.Normal);
			button.TouchUpInside += OnButtonPress;

			stack.AddArrangedSubview (button);

			button.WidthAnchor.ConstraintEqualTo (View.WidthAnchor, 0.85f).Active = true;
			button.HeightAnchor.ConstraintEqualTo (View.HeightAnchor, 0.05f).Active = true;
		}
	}
}
