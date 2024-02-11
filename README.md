# Audio Processing
[![Work in Progress](https://img.shields.io/badge/Status-Work%20in%20Progress-orange.svg)]()
[![Beta Version](https://img.shields.io/badge/Version-Beta-green.svg)]()\
Audio Processing is an advanced audio analysis and processing application designed to provide a wide range of features for audio enthusiasts and professionals.

## Key Features
- **Waveform Graphs:** Visualize audio waveforms in real-time.
- **Mono/Stereo Channels:** Support for both mono and stereo audio channels.
- **Logarithmic dB Scale VU Meter:** Accurate volume metering with a logarithmic dB scale.
- **FFT Graph:** Display real-time FFT (Fast Fourier Transform) graphs for frequency analysis.
- **Equalizer with Low/Mid/High Controls:** Fine-tune audio frequencies with dedicated potentiometers.
- **WAV Import:** Import and work with audio files in WAV format.
- **PrecisionSlider:** Custom slider with float precision, adjustable interval (even negative), and linear, logarithmic, or exponential scale.
- **VolumeMeter:** VuMeter with dB values in a logarithmic scale for precise volume measurement.
- **Microphone Profiling (Upcoming):** Capture and analyze audio from connected microphones.
- **PC Audio Profiling (Upcoming):** Profile audio output from the computer for comprehensive analysis.
- **Pitch Shifting:** Manipulate pitch and perform effects.
- **Time Stretching:** Implement time-stretching techniques for audio modification.
- **Variable Speed without Pitch Influence:** Adjust playback speed without affecting pitch.
- **Tuner:** Analyze and determine the current musical note using FFT.

## Graphs Features
The graphs in Audio Processing offer a range of powerful features to enhance your audio analysis experience.
### Waveform Graph
Visualize audio waveforms in real-time, using both mono and stereo visualization or EQ visualization. Equalization, time-stretching, pitch-shifting, zoom and other effects are handled and displayed on every graph and specific graphs.
### Zoom Functionality
Zooming in and out of the waveform provides a detailed view of your audio data. With a simple scroll on the PrecisionSlider, you can dynamically adjust the zoom level, allowing you to focus on specific portions of the audio.
### Volume Adjustment
Easily adjust the volume of your audio using the volume slider. A user-friendly volume control allows you to increase or decrease the amplitude, ensuring optimal audio levels for playback or analysis.
### Mono/Stereo Selection
The waveform graph supports both mono and stereo audio channels. Switch effortlessly between mono and stereo modes to analyze and edit audio with different channel configurations.
### Pan Adjustment
Fine-tune the stereo image of your audio by adjusting the pan control. Shift the audio balance between the left and right channels for optimal spatial representation.
### Equalizer (EQ) Controls
The integrated equalizer offers Low, Mid, and High frequency controls with dedicated potentiometers. Effortlessly shape your audio's tonal characteristics to achieve the desired sound profile.
### Fast Fourier Transform (FFT) Graph
Visualize the frequency content of your audio with the real-time FFT graph. Identify prominent frequencies and gain insights into the spectral composition of your audio.
### Tuner Functionality
The Tuner feature uses FFT analysis to identify the dominant frequency or frequency range in the audio. This provides a convenient way to determine the current musical note.


## Custom Controls
<img align="right" src="docs/img/volume-meter.png" alt="VolumeMeter" height="250px">

### PrecisionSlider
The PrecisionSlider is a custom slider (trackbar) designed to provide float precision, a customizable interval (even allowing negative values), and the flexibility of linear, logarithmic, or exponential scales.
### VolumeMeter
The VolumeMeter is a VuMeter that accurately measures volume in a logarithmic dB scale, offering precise monitoring similar to analog or digital vu meters.

## Requirements
- Libraries: [NAudio](https://github.com/naudio/NAudio), [ScottPlot](https://github.com/ScottPlot/ScottPlot)

## Known Issues
- **Microphone Profiling**: The current version does not support microphone profiling.
- **PC Audio Capturing**: Capturing audio directly from the PC is not functional in the current release.

### Important
Please note that this project is currently in an alpha/beta stage, and there might be various bugs or issues present. The current version has been pushed to the repository to provide early access to a range of features. Additional functionalities are actively being planned and will be added shortly.
Feel free to report any issues or bugs you encounter, and thank you for your understanding as we work to improve and enhance the software!
