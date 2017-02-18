# GoodAI Brain Simulator AIWORKER

**New with School for AI (read more here: [http://blog.marekrosa.org/2016/12/goodai-releases-school-for-ai-new_1.html](http://blog.marekrosa.org/2016/12/goodai-releases-school-for-ai-new_1.html)).**

Brain Simulator is a collaborative platform for researchers, developers and high-tech companies to prototype and simulate artificial brain architecture, share knowledge, and exchange feedback.

The platform is designed to simplify collaboration, testing, and the implementation of new theories, and to easily visualize experiments and data. No mathematical or programming background is required to experiment with Brain Simulator modules.

Please keep in mind that Brain Simulator and all included modules are still in the PROTOTYPE STAGE OF DEVELOPMENT. GoodAI will continuously improve the platform based on its own research advancement and user feedback.

## System Requirements

Running Brain Simulator requires an NVIDIA **CUDA-enabled graphics** card and **64-bit Windows**. More specifically, the requirements are:

* 64-bit Windows 7, 8, 8.1 or 10
* .NET Framework 4.5
* NVIDIA graphics card with CUDA support (compute capability 2.0 or higher)

### Building Brain Simulator

To build Brain Simulator, open the Sources/BrainSimulator.sln solution in Visual Studio 2015 Update 3. You need to have NVIDIA CUDA 8 installed.

To build the School and School GUI modules, open the Sources/Modules/School/School.sln solution and build the SchoolGUI project.
