<script setup></script>
<template>
    <section
        id="home"
        class="lg:h-[85vh] flex items-center bg-light-primary dark:bg-dark-primary py-32 lg:py-0 overflow-hidden"
    >
        <div class="container mx-auto h-full" v-motion :initial="{opacity:0,
    y:100,
    }"
    :visible="{opacity:1,
      y:0,
    }">
            <div class="flex flex-col md:flex-row items-center h-full pt-8">
                <div class="flex-1 flex flex-col items-center lg:items-start">
                    <p class="text-lg text-accent text-md mb-[22px]">
                        Hey, I'm Omar! 👋
                    </p>
                    <h1
                        class="text-4xl leading-[44px] md:text-5xl md:leading-tight lg:text-7xl lg:leading-[1.2] font-bold md:tracking-[-2px]"
                    >
                        I Build & Design <br />
                        Web Interfaces.
                    </h1>
                    <p
                        class="pt-4 pb-8 md:pt-6 md:pb-12 max-w-[480px] text-lg text-center lg:text-left"
                    >
                        Lorem ipsum dolor sit amet consectetur adipisicing illo
                        ad labore dolor elit.
                    </p>
                    <button
                        class="btn btn-md bg-accent hover:bg-light-secondary hover:text-light-tail-500 dark:hover:bg-dark-secondary dark:hover:text-dark-navy-100 md:btn-lg transition-all"
                    >
                        Work with me
                    </button>
                    <div class="pt-12">
                        <h5
                            class="text-lg flex items-center text-black dark:text-white mb-2"
                        >
                            Follow me on.
                        </h5>
                        <div class="flex items-center mb-6">
                            <a
                                class="w-12 h-12 rounded flex items-center justify-center text-dark hover:bg-light-secondary hover:border-light-secondary dark:hover:bg-secondary dark:hover:border-secondary mr-3 sm:mr-4"
                                href="https://www.linkedin.com/in/omar-ahmed-71a211288/"
                            >
                                <svg
                                    xmlns="http://www.w3.org/2000/svg"
                                    x="0px"
                                    y="0px"
                                    width="100"
                                    height="100"
                                    viewBox="0 0 48 48"
                                >
                                    <path
                                        fill="#0288D1"
                                        d="M42,37c0,2.762-2.238,5-5,5H11c-2.761,0-5-2.238-5-5V11c0-2.762,2.239-5,5-5h26c2.762,0,5,2.238,5,5V37z"
                                    ></path>
                                    <path
                                        fill="#FFF"
                                        d="M12 19H17V36H12zM14.485 17h-.028C12.965 17 12 15.888 12 14.499 12 13.08 12.995 12 14.514 12c1.521 0 2.458 1.08 2.486 2.499C17 15.887 16.035 17 14.485 17zM36 36h-5v-9.099c0-2.198-1.225-3.698-3.192-3.698-1.501 0-2.313 1.012-2.707 1.99C24.957 25.543 25 26.511 25 27v9h-5V19h5v2.616C25.721 20.5 26.85 19 29.738 19c3.578 0 6.261 2.25 6.261 7.274L36 36 36 36z"
                                    ></path>
                                </svg>
                            </a>
                            <!-- facebook -->
                            <a
                                class="w-12 h-12 rounded flex items-center justify-center text-dark hover:bg-light-secondary hover:border-light-secondary dark:hover:bg-secondary dark:hover:border-secondary mr-3 sm:mr-4"
                                href="https://www.facebook.com/omer.ahmed.5076798/?locale=ar_AR"
                            >
                                <svg
                                    xmlns="http://www.w3.org/2000/svg"
                                    x="0px"
                                    y="0px"
                                    width="100"
                                    height="100"
                                    viewBox="0 0 48 48"
                                >
                                    <path
                                        fill="#3F51B5"
                                        d="M42,37c0,2.762-2.238,5-5,5H11c-2.761,0-5-2.238-5-5V11c0-2.762,2.239-5,5-5h26c2.762,0,5,2.238,5,5V37z"
                                    ></path>
                                    <path
                                        fill="#FFF"
                                        d="M34.368,25H31v13h-5V25h-3v-4h3v-2.41c0.002-3.508,1.459-5.59,5.592-5.59H35v4h-2.287C31.104,17,31,17.6,31,18.723V21h4L34.368,25z"
                                    ></path>
                                </svg>
                            </a>
                            <!-- github -->
                            <a
                                class="w-12 h-12 rounded flex items-center justify-center text-dark hover:bg-light-secondary hover:border-light-secondary dark:hover:bg-secondary dark:hover:border-secondary mr-3 sm:mr-4"
                                href="https://github.com/3morii74"
                            >
                            <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" width="100" height="100" viewBox="0 0 100 100">
<circle cx="52" cy="52" r="44" opacity=".35"></circle><circle cx="50" cy="50" r="44" fill="#f2f2f2"></circle><path fill="#707cc0" d="M50,12.5c-20.711,0-37.5,16.789-37.5,37.5S29.289,87.5,50,87.5S87.5,70.711,87.5,50 S70.711,12.5,50,12.5z"></path><path fill="#f2f2f2" d="M60.161,83.936c0-1.122,0.042-4.813,0.042-9.389c0-3.192-1.095-5.281-2.324-6.338 c7.624-0.847,15.626-3.74,15.626-16.888c0-3.736-1.324-6.791-3.518-9.184c0.352-0.866,1.527-4.346-0.341-9.057 c0,0-2.868-0.92-9.402,3.508c-2.734-0.759-5.662-1.139-8.568-1.152c-2.91,0.013-5.838,0.393-8.568,1.152 c-6.538-4.429-9.411-3.508-9.411-3.508c-1.862,4.712-0.687,8.192-0.336,9.057c-2.189,2.393-3.523,5.448-3.523,9.184 c0,13.115,7.99,16.051,15.589,16.915c-0.978,0.856-1.862,2.364-2.173,4.575c-1.95,0.876-6.907,2.386-9.96-2.844 c0,0-1.808-3.285-5.242-3.527c0,0-3.342-0.043-0.235,2.08c0,0,2.244,1.053,3.8,5.006c0,0,2.009,6.656,11.529,4.588 c0.017,2.856,0.046,5.008,0.046,5.821c0,0.385-0.122,0.792-0.383,1.115C45.945,86.292,49.3,87,52.807,87 c2.981,0,5.853-0.509,8.576-1.417C60.502,85.37,60.161,84.613,60.161,83.936z"></path><path fill="#40396e" d="M50,89c-21.505,0-39-17.495-39-39s17.495-39,39-39s39,17.495,39,39S71.505,89,50,89z M50,14 c-19.851,0-36,16.149-36,36s16.149,36,36,36s36-16.149,36-36S69.851,14,50,14z"></path>
</svg>
                            </a>
                        </div>
                    </div>
                </div>
                <div
                    class="flex flex-1 justify-end items-center h-full mt-8 md:mt-0"
                >
                    <img
                        class="rounded-lg"
                        src="https://github.com/3morii74/portfolio/blob/main/450559652_2745879958905113_7244495243180391719_n.jpg?raw=true"
                        alt="Hero"
                    />
                </div>
            </div>
        </div>
    </section>
</template>
